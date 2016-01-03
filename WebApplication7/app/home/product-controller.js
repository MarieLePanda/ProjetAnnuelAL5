angular.module('mon-application')
    .controller('products-controller', function ($scope, $http) {
        $http.get(uri)
            .success(function (data) {
                $scope.products = data;
            })
            .error(function (error) {
                alert('error' + error);
            });

        $scope.search = function () {
            $http.get(uri + '/' + $scope.id).then(function (result) {
                $scope.searched = result.data;
            });
        }
    });