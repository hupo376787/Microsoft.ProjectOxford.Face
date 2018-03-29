using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Face
{
    public interface IFaceServiceClient
    {
        HttpRequestHeaders DefaultRequestHeaders
        {
            get;
        }

        Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, string imageUrl, string userData = null, FaceRectangle targetFace = null);

        Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, Stream imageStream, string userData = null, FaceRectangle targetFace = null);

        Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, string imageUrl, string userData = null, FaceRectangle targetFace = null);

        Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, Stream imageStream, string userData = null, FaceRectangle targetFace = null);

        Task CreateFaceListAsync(string faceListId, string name, string userData);

        Task<CreatePersonResult> CreatePersonAsync(string personGroupId, string name, string userData = null);

        Task CreatePersonGroupAsync(string personGroupId, string name, string userData = null);

        Task DeleteFaceFromFaceListAsync(string faceListId, Guid persistedFaceId);

        Task DeleteFaceListAsync(string faceListId);

        Task DeletePersonAsync(string personGroupId, Guid personId);

        Task DeletePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId);

        Task DeletePersonGroupAsync(string personGroupId);

        Task<Contract.Face[]> DetectAsync(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);

        Task<Contract.Face[]> DetectAsync(Stream imageStream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null);

        Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20);

        Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20);

        Task<FaceList> GetFaceListAsync(string faceListId);

        Task<Person> GetPersonAsync(string personGroupId, Guid personId);

        Task<PersonFace> GetPersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId);

        Task<PersonGroup> GetPersonGroupAsync(string personGroupId);

        Task<PersonGroup[]> GetPersonGroupsAsync();

        Task<TrainingStatus> GetPersonGroupTrainingStatusAsync(string personGroupId);

        Task<Person[]> GetPersonsAsync(string personGroupId);

        Task<GroupResult> GroupAsync(Guid[] faceIds);

        Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds, int maxNumOfCandidatesReturned = 1);

        Task<FaceListMetadata[]> ListFaceListsAsync();

        Task TrainPersonGroupAsync(string personGroupId);

        Task UpdateFaceListAsync(string faceListId, string name, string userData);

        Task UpdatePersonAsync(string personGroupId, Guid personId, string name, string userData = null);

        Task UpdatePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId, string userData = null);

        Task UpdatePersonGroupAsync(string personGroupId, string name, string userData = null);

        Task<VerifyResult> VerifyAsync(Guid faceId1, Guid faceId2);
    }
}