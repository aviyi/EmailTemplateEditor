app.controller('templateEditorCtrl', ['$scope', '$stateParams', 'emailTempalteService', function ($scope, $stateParams, emailTempalteService) {

    $scope.model = {};
    init();
    function init() {
        $scope.model.type = $stateParams.type;

        emailTempalteService.getBranch($stateParams.id).then(function (resposne) {
            $scope.model = resposne.data[0];
        })

    }
    $scope.save = function () {
        addTemplateForBranch();
    }

    function addTemplateForBranch() {
        emailTempalteService.addForBranch($scope.model.selectedBranch.originalObject.id, $scope.model.subject, $scope.model.body)
        .then(function (response) {
            if (response.data == 'true') {
                alert('added')
            }
        })

    }

    function addTemplateForC() {
        emailTempalteService.addForBranch(1, $scope.model.subject, $scope.model.body).then(function (response) {

            if (response.data == 'true') {
                alert('added')
            }
        })
    }


}])