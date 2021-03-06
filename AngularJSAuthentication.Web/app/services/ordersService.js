﻿'use strict';
app.factory('ordersService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var ordersServiceFactory = {};

    var _getOrders = function () {

        return $http.get(serviceBase + 'api/orders').then(function (results) {
            return results;
        });
    };

    var _doTest = function () {

        return $http.get('appApi/api/values').then(function (results) {
            return results;
        });
    };

    ordersServiceFactory.getOrders = _getOrders;
    ordersServiceFactory.doTest = _doTest;

    return ordersServiceFactory;

}]);