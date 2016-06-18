﻿using Parse;
using System;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Policy")]
    public class PolicyVM : ViewModel
    {
        [ParseFieldName("previousNumber")]
        public string PreviousNumber { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("client")]
        public ParseObject Client { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("period")]
        public int Period { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("startDate")]
        public System.DateTime StartDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("endDate")]
        public System.DateTime EndDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("requestDate")]
        public System.DateTime RequestDate { get { return GetProperty<DateTime>(); } set { SetProperty<DateTime>(value); } }
        [ParseFieldName("receptionDate")]
        public Nullable<System.DateTime> ReceptionDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("emissionDate")]
        public Nullable<System.DateTime> EmissionDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("prima")]
        public double Prima { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("premium")]
        public double Premium { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("surcharge")]
        public double Surcharge { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("bonus")]
        public Nullable<double> Bonus { get { return GetProperty<Nullable<double>>(); } set { SetProperty<Nullable<double>>(value); } }
        [ParseFieldName("value")]
        public double Value { get { return GetProperty<double>(); } set { SetProperty<double>(value); } }
        [ParseFieldName("notes")]
        public string Notes { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("number")]
        public string Number { get { return GetProperty<string>(); } set { SetProperty<string>(value); } }
        [ParseFieldName("isRenovated")]
        public bool IsRenovated { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("isAnnulled")]
        public bool IsAnnulled { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("annulationDate")]
        public Nullable<System.DateTime> AnnulationDate { get { return GetProperty<Nullable<System.DateTime>>(); } set { SetProperty<Nullable<System.DateTime>>(value); } }
        [ParseFieldName("isRemoved")]
        public bool IsRemoved { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
        [ParseFieldName("producer")]
        public ParseObject Producer { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("collector")]
        public ParseObject Collector { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
        [ParseFieldName("risk")]
        public ParseObject Risk { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}