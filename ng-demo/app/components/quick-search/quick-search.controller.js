(function () {
  angular.module('app').controller('QuickSearchCtrl', QuickSearchCtrl);

  QuickSearchCtrl.$inject = ['UtilityService', '$state'];

  function QuickSearchCtrl(UtilityService, $state) {
    var vm = this;

    init(vm);

    function init(vm) {
      vm.search = search;
    }

    function search() {
      var params = { criteria: vm.searchText };
      $state.go('search', params);
    }
  }
})();