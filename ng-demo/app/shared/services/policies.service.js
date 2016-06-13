(function () {
  angular.module('app').factory('PoliciesService', PoliciesService);

  PoliciesService.$inject = ['$resource'];

  function PoliciesService($resource) {
    return $resource(
      'classes/Policy/:policyId', {
        policyId: '@policyId'
      }, {
        query: {
          url: 'classes/Policy',
          method: 'GET',
          isArray: false
        }
      });
  }
})();