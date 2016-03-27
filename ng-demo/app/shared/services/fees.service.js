(function () {
  angular.module('app').factory('FeesService', FeesService);

  FeesService.$inject = ['$resource'];

  function FeesService($resource) {
    return $resource(
      'classes/Fee/:feeId', {
        policyId: '@feeId'
      }, {
        query: {
          url: 'classes/Fee',
          method: 'GET',
          isArray: false
        }
      });
  }
})();