angular
    .module('mon-application', ['ui.router'])
    .config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
    $urlRouterProvider.otherwise('/home');
    $stateProvider
        .state('home', {
            url: '/home',
            templateUrl: '/app/home/home.html'
        })
        .state('home.quelquechose', {
            url:'/test',
            template: 'My Contacts'
        })
    ;
}]);
var uri = 'api/products';