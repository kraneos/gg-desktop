(function () {
  angular.module('app').config(configure);

  configure.$inject = ['$stateProvider'];

  function configure($stateProvider) {
    $stateProvider
      .state('home', {
        url: '',
        views: {
          main: {
            templateUrl: 'wwwroot/components/home/home-index.view.html',
            controller: 'HomeIndexCtrl',
            controllerAs: 'hCtrl'
          }
        }
      })
      .state('policies', {
        url: '/policies',
        views: {
          main: {
            templateUrl: 'wwwroot/components/policies/policies-index.view.html',
            controller: 'PoliciesIndexCtrl',
            controllerAs: 'pCtrl'
          }
        }
      })
      .state('fees', {
        url: '/policies/:policyId/fees',
        views: {
          main: {
            templateUrl: 'wwwroot/components/policies/fees-index.view.html',
            controller: 'FeesIndexCtrl',
            controllerAs: 'fCtrl'
          }
        }
      });
  }
})();