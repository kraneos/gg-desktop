(function () {
  angular.module('app').factory('AddressesService', AddressesService);

  AddressesService.$inject = ['$resource'];

  function AddressesService($resource) {
    return $resource(
      'classes/Address/:addressId', {
        addressId: '@addressId'
      }, {
        query: {
          isArray: false
        }
      });
  }
})();