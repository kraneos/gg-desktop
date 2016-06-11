var dataMig = require('./data-migration');

var dm = dataMig('http://seggu-api-test.herokuapp.com/parse/', 'seggu-api', 'SegguMasterKey');
// dm.createProvinces('./data/provinces.json');
// dm.createDistricts('./data/provinces.new.json', './data/districts.json');
// dm.createLocalities('./data/districts.new.json', './data/localities.json');
dm.createBanks('./data/banks.json');
