(function () {
    angular.module("BlakWealth")
        .factory("pathwayComponentFactory", pathwayComponentFactory);
    pathwayComponentFactory.$inject = ["$http", "$q"];

    function pathwayComponentFactory($http, $q) {
        function _get() {
            settings = {
                url: "/pathway"
                , cache: false
                , method: 'GET'
                , responseType: 'json'
            };
            return $http(settings)
                .then(_getSuccess, _getError);
        };

        function _getSuccess(response) {
            return response;
        };

        function _getError(error) {
            return $q.reject("this is a get error");
        };

        return {
            get: _get
        };
    };
})();

(function () {
    angular.module('BlakWealth')
        .controller('pathwayComponentController', pathwayComponentController);
    pathwayComponentController.$inject = ['pathwayComponentFactory', '$state', 'alertService'];

    function pathwayComponentController(pathwayComponentFactory, $state, alertService) {
        var vm = this;
        vm.get = _getData;
        vm.data = {};
        vm.$onInit = _onInit;

        function _onInit() {
            vm.get();
        };

        function _getData() {
            pathwayComponentFactory.get()
                .then(_getDataSuccess, _getDataError);
        };

        function _getDataSuccess(response) {
            vm.data.items = response.data.items;
        };

        function _getDataError(error) {
            alertService.error("There was an error in retrieving the data");
        };

    }
})();

(function () {
    angular.module('BlakWealth')
        .component('pathwayComponent', {
            templateUrl: 'pathwaycomponent/pathwaycomponent.html'
            , controller: 'pathwayComponentController'
            , controllerAs: 'c'
            , bindings: {
                pathwayId: '<'
            }
        });
})();
