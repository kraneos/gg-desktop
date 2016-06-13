(function () {
  angular.module('app').controller('PoliciesFormCtrl', PoliciesFormCtrl);

  PoliciesFormCtrl.$inject = ['$stateParams', 'PoliciesService', 'VehiclesService', 'FeesService', 'UtilityService'];

  function PoliciesFormCtrl($stateParams, PoliciesService, VehiclesService, FeesService, UtilityService) {
    var vm = this;

    init(vm);

    function init(vm) {
      vm.policy = {};
      vm.vehicles = [];
      vm.fees = [];

      if ($stateParams.policyId) {
        searchPolicy();
        searchVehicle();
        searchFees();
      }
    }

    function searchPolicy() {
      PoliciesService.get($stateParams).$promise.then(onGetSucceded, UtilityService.onRequestError);

      function onGetSucceded(res) {
        vm.policy = res;
      }
    }

    function searchVehicle() {
      var params = { where: { policy: { __type: 'Pointer', className: 'Policy', objectId: $stateParams.policyId } } };
      VehiclesService.query(params).$promise.then(onGetSucceded, UtilityService.onRequestError);

      function onGetSucceded(res) {
        vm.vehicles = res.results;
      }
    }

    function searchFees() {
      var params = { where: { policy: { __type: 'Pointer', className: 'Policy', objectId: $stateParams.policyId } } };      
      FeesService.query(params).$promise.then(onGetSucceded, UtilityService.onRequestError);

      function onGetSucceded(res) {
        vm.fees = res.results;
      }
    }
  }
})();