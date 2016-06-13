(function () {
  angular.module('app').factory('ClientsService', ClientsService);

  ClientsService.$inject = ['$resource'];

  function ClientsService($resource) {
    return $resource(
      'classes/Client/:clientId', {
        clientId: '@clientId'
      }, {
        query: {
          isArray: false
        }
      });
  }
})();