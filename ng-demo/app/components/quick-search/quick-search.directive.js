(function () {
  angular.module('app').directive('sgQuickSearch', sgQuickSearch);
  
  sgQuickSearch.$inject = [];
  
  function sgQuickSearch() {
    return {
      restrict: 'E',
      templateUrl: 'wwwroot/components/quick-search/quick-search.view.html',
      controller: 'QuickSearchCtrl',
      controllerAs: 'ctrl',
      bindToController: true
    };
  }
})();