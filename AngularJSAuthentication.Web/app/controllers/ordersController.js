'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];

    ordersService.getOrders().then(function (results) {

    });

    ordersService.doTest().then(function (results) {

        alert("tested");

    }, function (error) {
        alert(error.data.message);
    });

}]);