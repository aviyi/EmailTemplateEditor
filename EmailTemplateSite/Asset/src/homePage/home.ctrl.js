﻿app.controller('homeCtrl', ['$scope', '$state', function ($scope, $state) {


    $scope.onBranchClicked = function () {



        goTo('/templateEditor', { type: 'brach' })
    }
    $scope.onCampaignClicked = function () {

        goTo('/templateEditor', { type: 'campaign' })
    }
    function goTo(state, params) {
        $state.go(state, params)
    }
}])