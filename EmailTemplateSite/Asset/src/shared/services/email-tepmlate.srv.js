app.service('emailTempalteService', ['$http', function ($http) {

    function addForBranch(branchId, subject, body) {
        var data = {
            branchId: branchId,
            subject: subject,
            body: body
        }
        return $http.post('/api/EmailTemplate/AddForBranch', data)
    }
    function addForCampaign(CampaigId, subject, body) {
        var data = {
            branchId: CampaigId,
            subject: subject,
            body: body
        }
        return $http.post('/api/EmailTemplate/AddForCampaign', data)
    }

    function getBranch(branchId)
    {
        return $http.get({ url: '/api/EmailTemplate/GetBranches', params: { branchId: branchId } })
    }
   
 
    return {
        addForBranch: addForBranch,
        addForCampaign: addForCampaign,
        getBranch: getBranch
    }
}])