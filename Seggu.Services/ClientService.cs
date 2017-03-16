using Seggu.Daos.Interfaces;
using Seggu.Dtos;
using Seggu.Services.DtoMappers;
using Seggu.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Net.Mail;

namespace Seggu.Services
{
    public sealed class ClientService : IClientService
    {
        private IClientDao clientDao;
        private IAddressDao addressDao;
        private IEmailService emailService;
        private ISettingsDao settingsDao;

        public ClientService(IClientDao clientDao, IAddressDao addressDao, IEmailService emailService, ISettingsDao settingsDao)
        {
            this.clientDao = clientDao;
            this.addressDao = addressDao;
            this.emailService = emailService;
            this.settingsDao = settingsDao;
        }

        public void Save(ClientFullDto clientInformation)
        {
            var isNew = clientInformation.Id == default(int);
            var client = ClientDtoMapper.GetObject(clientInformation);
            if (isNew)
            {
                var clientId = this.clientDao.Save(client);
                SendNewClientEmail(clientId, clientInformation);
            }
            else
            {
                this.clientDao.Update(client);
            }

            clientInformation.Id = (int)client.Id;

            #region Home Address

            var homeAddress = AddressDtoMapper.GetHome(clientInformation);
            if (homeAddress.Id == default(int))
                this.addressDao.Save(homeAddress);
            else
                this.addressDao.Update(homeAddress);

            #endregion

            #region Collection Address

            var collectionAddress = AddressDtoMapper.GetCollection(clientInformation);
            if (collectionAddress.Id == default(int))
                this.addressDao.Save(collectionAddress);
            else
                this.addressDao.Update(collectionAddress);

            #endregion
        }

        private void SendNewClientEmail(long clientId, ClientFullDto clientInformation)
        {
            var setting = this.settingsDao.GetLastLogin();
            var message = new MailMessage();
            //message.From = new MailAddress(setting.Email);
            message.To.Add(clientInformation.Mail);
            message.Subject = "Nuevo usuario Seggu";
            message.Body =
                $@"Estimado, para comenzar a ver las pólizas en su celular puede entrar a este enlace.
                {Properties.Settings.Default.AppSegguUrl}/seggu-clients/{setting.SegguClientId}/register";
            this.emailService.Send(message);
        }

        public IEnumerable<ClientIndexDto> GetByDNI(string str)
        {
            var clients = this.clientDao.GetByDni(str);
            return clients.Select(x => ClientDtoMapper.GetIndexDto(x));
        }

        public IEnumerable<ClientIndexDto> GetByName(string str)
        {
            var clients = this.clientDao.GetByFullName(str);
            return clients.Select(x => ClientDtoMapper.GetIndexDto(x));
        }

        public IEnumerable<ClientIndexDto> GetAll()
        {
            var clients = this.clientDao.GetAll().OrderBy(x => x.LastName);
            return clients.Select(x => ClientDtoMapper.GetIndexDto(x));
        }

        public ClientIndexDto GetShortDtoById(int clientId)
        {
            var client = this.clientDao.Get(clientId);
            return ClientDtoMapper.GetIndexDto(client);
        }

        public ClientFullDto GetById(int clientId)
        {
            var id = clientId;
            var client = this.clientDao.Get(id);
            return ClientDtoMapper.GetDto(client);
        }
        public IEnumerable<ClientIndexDto> GetValids()
        {
            var clients = this.clientDao.GetValids().OrderBy(x => x.LastName);
            return clients.Select(x => ClientDtoMapper.GetIndexDto(x));
        }

        public bool ExistsDocument(string dni)
        {
            return this.clientDao.ExistsDocument(dni);
        }
    }
}
