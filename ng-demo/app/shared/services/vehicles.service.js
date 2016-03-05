(function () {
  angular.module('app').factory('VehiclesService', VehiclesService);

  VehiclesService.$inject = ['$resource'];

  function VehiclesService($resource) {
    return $resource(
      'classes/Vehicle/:vehicleId', {
        vehicleId: '@vehicleId'
      }, {
        query: {
          isArray: false
        }
      });
  }
})();