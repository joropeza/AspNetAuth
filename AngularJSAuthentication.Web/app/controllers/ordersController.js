'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];

    ordersService.getOrders().then(function (results) {

    });


}]);