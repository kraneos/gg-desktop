(function () {
  angular.module('app').controller('SearchCtrl', SearchCtrl);

  SearchCtrl.$inject = ['$stateParams', 'VehiclesService', 'ClientsService', 'UtilityService'];

  function SearchCtrl($stateParams, VehiclesService, ClientsService, UtilityService) {
    var vm = this;

    init(vm);

    function init(vm) {
      vm.vehicles = [];
      vm.clients = [];
      
      if ($stateParams.criteria) {
        vm.criteria = $stateParams.criteria;
        searchVehicles($stateParams.criteria);
        searchClients($stateParams.criteria);
      }
    }

    function searchVehicles(criteria) {
      var params = {
        where: {
          plate: {
            $regex: criteria,
            $options: 'i'
          }
        },
        include: 'policy'
      };

      VehiclesService.query(params).$promise.then(onQuerySucceded, UtilityService.onRequestError);

      function onQuerySucceded(res) {
        vm.vehicles = res.results;
      }
    }

    function searchClients(criteria) {
      var params = {
        where: {
          lastName: {
            $regex: criteria,
            $options: 'i'
          }
        }
      };

      ClientsService.query(params).$promise.then(onQuerySucceded, UtilityService.onRequestError);

      function onQuerySucceded(res) {
        vm.clients = res.results;
      }
    }
  }
})();