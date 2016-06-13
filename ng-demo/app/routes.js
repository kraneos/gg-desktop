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
      .state('home-slash', {
        url: '/',
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
      .state('policiesDetails', {
        url: '/policies/:policyId/details',
        views: {
          main: {
            templateUrl: 'wwwroot/components/policies/policies-form.view.html',
            controller: 'PoliciesFormCtrl',
            controllerAs: 'pfCtrl'
          }
        }
      })
      .state('clientsDetails', {
        url: '/clients/:clientId/details',
        views: {
          main: {
            templateUrl: 'wwwroot/components/clients/clients-details.view.html',
            controller: 'ClientsDetailsCtrl',
            controllerAs: 'cfCtrl'
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
      })
      .state('search', {
        url: '/search/:criteria',
        views: {
          main: {
            templateUrl: 'wwwroot/components/quick-search/search.view.html',
            controller: 'SearchCtrl',
            controllerAs: 'sCtrl'
          }
        }
      });
  }
})();