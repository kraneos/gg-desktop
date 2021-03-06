﻿using Parse;

namespace Seggu.Service.ViewModels
{
    [ParseClassName("Risk")]
    public class RiskVM : KeyValueViewModel
    {
        [ParseFieldName("riskType")]
        public int RiskType { get { return GetProperty<int>(); } set { SetProperty<int>(value); } }
        [ParseFieldName("company")]
        public ParseObject Company { get { return GetProperty<ParseObject>(); } set { SetProperty<ParseObject>(value); } }
    }
}
