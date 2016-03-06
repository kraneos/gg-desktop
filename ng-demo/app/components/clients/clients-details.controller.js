(function () {
  angular.module('app').controller('ClientsDetailsCtrl', ClientsDetailsCtrl);
  
  ClientsDetailsCtrl.$inject = ['$stateParams', 'ClientsService', 'UtilityService', 'AddressesService'];
  
  function ClientsDetailsCtrl($stateParams, ClientsService, UtilityService, AddressesService) {
    var vm = this;
    
    init(vm);
    
    function init(vm) {
      vm.client = {};
      vm.address = {};
      vm.googleMapsApiKey = 'AIzaSyBThTSYfeOx-lmsCVqd9-5s6iJAzuuP84k';
      
      if ($stateParams.clientId) {
        searchClient();
        searchAddress();
      }
    }
    
    function searchClient() {
      ClientsService.get($stateParams).$promise.then(onGetSucceded, UtilityService.onRequestError);

      function onGetSucceded(res) {
        vm.client = res;
      }
    }

    function searchAddress() {
      AddressesService.query().$promise.then(onGetSucceded, UtilityService.onRequestError);

      function onGetSucceded(res) {
        vm.address = res.results[0];
      }
    }
  }
})();