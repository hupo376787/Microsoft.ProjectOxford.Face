using Microsoft.ProjectOxford.Face.Contract;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Face
{
    public class FaceServiceClient : IDisposable, IFaceServiceClient
    {
        private const string SERVICE_HOST = "https://westus.api.cognitive.microsoft.com/face/v1.0";//"https://api.projectoxford.ai/face/v1.0";
        private const string SERVICE_HOST_CN = "https://api.cognitive.azure.cn/face/v1.0";

        private const string JsonContentTypeHeader = "application/json";

        private const string StreamContentTypeHeader = "application/octet-stream";

        private const string SubscriptionKeyName = "ocp-apim-subscription-key";

        private const string DetectQuery = "detect";

        private const string VerifyQuery = "verify";

        private const string TrainQuery = "train";

        private const string TrainingQuery = "training";

        private const string PersonGroupsQuery = "persongroups";

        private const string PersonsQuery = "persons";

        private const string FacesQuery = "faces";

        private const string PersistedFacesQuery = "persistedfaces";

        private const string FaceListsQuery = "facelists";

        private const string FindSimilarsQuery = "findsimilars";

        private const string IdentifyQuery = "identify";

        private const string GroupQuery = "group";

        private static JsonSerializerSettings s_settings;

        private string _subscriptionKey;

        private HttpClient _httpClient;

        public HttpRequestHeaders DefaultRequestHeaders
        {
            get
            {
                return this._httpClient.DefaultRequestHeaders;
            }
        }

        protected virtual string ServiceHost
        {
            get
            {
                return "https://api.projectoxford.ai/face/v1.0";
            }
        }

        protected virtual string ServiceHostCn
        {
            get
            {
                return "https://api.cognitive.azure.cn/face/v1.0";
            }
        }

        static FaceServiceClient()
        {
            FaceServiceClient.s_settings = new JsonSerializerSettings()
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public FaceServiceClient(string subscriptionKey)
        {
            this._subscriptionKey = subscriptionKey;
            this._httpClient = new HttpClient();
            this._httpClient.DefaultRequestHeaders.Add("ocp-apim-subscription-key", subscriptionKey);
        }

        public async Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, string imageUrl, string userData = null, FaceRectangle targetFace = null)
        {
            object empty;
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId, "persistedfaces", userData, null };
            if (targetFace == null)
            {
                empty = string.Empty;
            }
            else
            {
                object[] left = new object[] { targetFace.Left, targetFace.Top, targetFace.Width, targetFace.Height };
                empty = string.Format("{0},{1},{2},{3}", left);
            }
            serviceHost[5] = empty;
            string str = string.Format("{0}/{1}/{2}/{3}?userData={4}&targetFace={5}", serviceHost);
            AddPersistedFaceResult addPersistedFaceResult = await this.SendRequestAsync<object, AddPersistedFaceResult>(HttpMethod.Post, str, new { url = imageUrl });
            return addPersistedFaceResult;
        }

        public async Task<AddPersistedFaceResult> AddFaceToFaceListAsync(string faceListId, Stream imageStream, string userData = null, FaceRectangle targetFace = null)
        {
            object empty;
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId, "persistedfaces", userData, null };
            if (targetFace == null)
            {
                empty = string.Empty;
            }
            else
            {
                object[] left = new object[] { targetFace.Left, targetFace.Top, targetFace.Width, targetFace.Height };
                empty = string.Format("{0},{1},{2},{3}", left);
            }
            serviceHost[5] = empty;
            string str = string.Format("{0}/{1}/{2}/{3}?userData={4}&targetFace={5}", serviceHost);
            return await this.SendRequestAsync<object, AddPersistedFaceResult>(HttpMethod.Post, str, imageStream);
        }

        public async Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, string imageUrl, string userData = null, FaceRectangle targetFace = null)
        {
            object empty;
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId, "persistedfaces", userData, null };
            if (targetFace == null)
            {
                empty = string.Empty;
            }
            else
            {
                object[] left = new object[] { targetFace.Left, targetFace.Top, targetFace.Width, targetFace.Height };
                empty = string.Format("{0},{1},{2},{3}", left);
            }
            serviceHost[7] = empty;
            string str = string.Format("{0}/{1}/{2}/{3}/{4}/{5}?userData={6}&targetFace={7}", serviceHost);
            AddPersistedFaceResult addPersistedFaceResult = await this.SendRequestAsync<object, AddPersistedFaceResult>(HttpMethod.Post, str, new { url = imageUrl });
            return addPersistedFaceResult;
        }

        public async Task<AddPersistedFaceResult> AddPersonFaceAsync(string personGroupId, Guid personId, Stream imageStream, string userData = null, FaceRectangle targetFace = null)
        {
            object empty;
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId, "persistedfaces", userData, null };
            if (targetFace == null)
            {
                empty = string.Empty;
            }
            else
            {
                object[] left = new object[] { targetFace.Left, targetFace.Top, targetFace.Width, targetFace.Height };
                empty = string.Format("{0},{1},{2},{3}", left);
            }
            serviceHost[7] = empty;
            string str = string.Format("{0}/{1}/{2}/{3}/{4}/{5}?userData={6}&targetFace={7}", serviceHost);
            return await this.SendRequestAsync<Stream, AddPersistedFaceResult>(HttpMethod.Post, str, imageStream);
        }

        public async Task CreateFaceListAsync(string faceListId, string name, string userData)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Put, str, new { name = name, userData = userData });
        }

        public async Task<CreatePersonResult> CreatePersonAsync(string personGroupId, string name, string userData = null)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons" };
            string str = string.Format("{0}/{1}/{2}/{3}", serviceHost);
            CreatePersonResult createPersonResult = await this.SendRequestAsync<object, CreatePersonResult>(HttpMethod.Post, str, new { name = name, userData = userData });
            return createPersonResult;
        }

        public async Task CreatePersonGroupAsync(string personGroupId, string name, string userData = null)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Put, str, new { name = name, userData = userData });
        }

        public async Task DeleteFaceFromFaceListAsync(string faceListId, Guid persistedFaceId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId, "persistedfaces", persistedFaceId };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Delete, str, null);
        }

        public async Task DeleteFaceListAsync(string faceListId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Delete, str, null);
        }

        public async Task DeletePersonAsync(string personGroupId, Guid personId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Delete, str, null);
        }

        public async Task DeletePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId, "persistedfaces", persistedFaceId };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Delete, str, null);
        }

        public async Task DeletePersonGroupAsync(string personGroupId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Delete, str, null);
        }

        public async Task<Contract.Face[]> DetectAsync(string imageUrl, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            Contract.Face[] faceArray;
            if (returnFaceAttributes == null)
            {
                object[] serviceHost = new object[] { this.ServiceHostCn, "detect", returnFaceId, returnFaceLandmarks };
                string str = string.Format("{0}/{1}?returnFaceId={2}&returnFaceLandmarks={3}", serviceHost);
                Contract.Face[] faceArray1 = await this.SendRequestAsync<object, Contract.Face[]>(HttpMethod.Post, str, new { url = imageUrl });
                faceArray = faceArray1;
            }
            else
            {
                object[] objArray = new object[] { this.ServiceHostCn, "detect", returnFaceId, returnFaceLandmarks, FaceServiceClient.GetAttributeString(returnFaceAttributes) };
                string str1 = string.Format("{0}/{1}?returnFaceId={2}&returnFaceLandmarks={3}&returnFaceAttributes={4}", objArray);
                Contract.Face[] faceArray2 = await this.SendRequestAsync<object, Contract.Face[]>(HttpMethod.Post, str1, new { url = imageUrl });
                faceArray = faceArray2;
            }
            return faceArray;
        }

        public async Task<Contract.Face[]> DetectAsync(Stream imageStream, bool returnFaceId = true, bool returnFaceLandmarks = false, IEnumerable<FaceAttributeType> returnFaceAttributes = null)
        {
            Contract.Face[] faceArray;
            if (returnFaceAttributes == null)
            {
                object[] serviceHost = new object[] { this.ServiceHostCn, "detect", returnFaceId, returnFaceLandmarks };
                string str = string.Format("{0}/{1}?returnFaceId={2}&returnFaceLandmarks={3}", serviceHost);
                Contract.Face[] faceArray1 = await this.SendRequestAsync<Stream, Contract.Face[]>(HttpMethod.Post, str, imageStream);
                faceArray = faceArray1;
            }
            else
            {
                object[] objArray = new object[] { this.ServiceHostCn, "detect", returnFaceId, returnFaceLandmarks, FaceServiceClient.GetAttributeString(returnFaceAttributes) };
                string str1 = string.Format("{0}/{1}?returnFaceId={2}&returnFaceLandmarks={3}&returnFaceAttributes={4}", objArray);
                Contract.Face[] faceArray2 = await this.SendRequestAsync<Stream, Contract.Face[]>(HttpMethod.Post, str1, imageStream);
                faceArray = faceArray2;
            }
            return faceArray;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this._httpClient != null)
            {
                this._httpClient.Dispose();
                this._httpClient = null;
            }
        }

        ~FaceServiceClient()
        {
            this.Dispose(false);
        }

        public async Task<SimilarFace[]> FindSimilarAsync(Guid faceId, Guid[] faceIds, int maxNumOfCandidatesReturned = 20)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "findsimilars" };
            string str = string.Format("{0}/{1}", serviceHost);
            SimilarFace[] similarFaceArray = await this.SendRequestAsync<object, SimilarFace[]>(HttpMethod.Post, str, new { faceId = faceId, faceIds = faceIds, maxNumOfCandidatesReturned = maxNumOfCandidatesReturned });
            return similarFaceArray;
        }

        public async Task<SimilarPersistedFace[]> FindSimilarAsync(Guid faceId, string faceListId, int maxNumOfCandidatesReturned = 20)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "findsimilars" };
            string str = string.Format("{0}/{1}", serviceHost);
            SimilarPersistedFace[] similarPersistedFaceArray = await this.SendRequestAsync<object, SimilarPersistedFace[]>(HttpMethod.Post, str, new { faceId = faceId, faceListId = faceListId, maxNumOfCandidatesReturned = maxNumOfCandidatesReturned });
            return similarPersistedFaceArray;
        }

        public static string GetAttributeString(IEnumerable<FaceAttributeType> types)
        {
            return string.Join(",", types.Select<FaceAttributeType, string>((FaceAttributeType attr) =>
            {
                string str = attr.ToString();
                return string.Concat(char.ToLowerInvariant(str[0]).ToString(), str.Substring(1));
            }).ToArray<string>());
        }

        public async Task<FaceList> GetFaceListAsync(string faceListId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            return await this.SendRequestAsync<object, FaceList>(HttpMethod.Get, str, null);
        }

        public async Task<Person> GetPersonAsync(string personGroupId, Guid personId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}", serviceHost);
            return await this.SendRequestAsync<object, Person>(HttpMethod.Get, str, null);
        }

        public async Task<PersonFace> GetPersonFaceAsync(string personGroupId, Guid personId, Guid persistedFace)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId, "persistedfaces", persistedFace };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", serviceHost);
            return await this.SendRequestAsync<object, PersonFace>(HttpMethod.Get, str, null);
        }

        public async Task<PersonGroup> GetPersonGroupAsync(string personGroupId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            return await this.SendRequestAsync<object, PersonGroup>(HttpMethod.Get, str, null);
        }

        public async Task<PersonGroup[]> GetPersonGroupsAsync()
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups" };
            string str = string.Format("{0}/{1}", serviceHost);
            return await this.SendRequestAsync<object, PersonGroup[]>(HttpMethod.Get, str, null);
        }

        public async Task<TrainingStatus> GetPersonGroupTrainingStatusAsync(string personGroupId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "training" };
            string str = string.Format("{0}/{1}/{2}/{3}", serviceHost);
            return await this.SendRequestAsync<object, TrainingStatus>(HttpMethod.Get, str, null);
        }

        public async Task<Person[]> GetPersonsAsync(string personGroupId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons" };
            string str = string.Format("{0}/{1}/{2}/{3}", serviceHost);
            return await this.SendRequestAsync<object, Person[]>(HttpMethod.Get, str, null);
        }

        public async Task<GroupResult> GroupAsync(Guid[] faceIds)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "group" };
            string str = string.Format("{0}/{1}", serviceHost);
            GroupResult groupResult = await this.SendRequestAsync<object, GroupResult>(HttpMethod.Post, str, new { faceIds = faceIds });
            return groupResult;
        }

        public async Task<IdentifyResult[]> IdentifyAsync(string personGroupId, Guid[] faceIds, int maxNumOfCandidatesReturned = 1)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "identify" };
            string str = string.Format("{0}/{1}", serviceHost);
            IdentifyResult[] identifyResultArray = await this.SendRequestAsync<object, IdentifyResult[]>(HttpMethod.Post, str, new { personGroupId = personGroupId, faceIds = faceIds, maxNumOfCandidatesReturned = maxNumOfCandidatesReturned });
            return identifyResultArray;
        }

        public async Task<FaceListMetadata[]> ListFaceListsAsync()
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists" };
            string str = string.Format("{0}/{1}", serviceHost);
            return await this.SendRequestAsync<object, FaceListMetadata[]>(HttpMethod.Get, str, null);
        }

        private async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod httpMethod, string requestUrl, TRequest requestBody)
        {
            TResponse tResponse;
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, this.ServiceHostCn)
            {
                RequestUri = new Uri(requestUrl)
            };
            if (requestBody != null)
            {
                if (!((object)requestBody is Stream))
                {
                    httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestBody, FaceServiceClient.s_settings), Encoding.UTF8, "application/json");
                }
                else
                {
                    httpRequestMessage.Content = new StreamContent((object)requestBody as Stream);
                    httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                }
            }
            HttpResponseMessage httpResponseMessage = await this._httpClient.SendAsync(httpRequestMessage);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.Content != null && httpResponseMessage.Content.Headers.ContentType.MediaType.Contains("application/json"))
                {
                    string str = await httpResponseMessage.Content.ReadAsStringAsync();
                    ClientError clientError = JsonConvert.DeserializeObject<ClientError>(str);
                    if (clientError.Error == null)
                    {
                        ServiceError serviceError = JsonConvert.DeserializeObject<ServiceError>(str);
                        if (clientError == null)
                        {
                            throw new FaceAPIException("Unknown", "Unknown Error", httpResponseMessage.StatusCode);
                        }
                        throw new FaceAPIException(serviceError.ErrorCode, serviceError.Message, httpResponseMessage.StatusCode);
                    }
                    throw new FaceAPIException(clientError.Error.ErrorCode, clientError.Error.Message, httpResponseMessage.StatusCode);
                }
                httpResponseMessage.EnsureSuccessStatusCode();
                tResponse = default(TResponse);
            }
            else
            {
                string str1 = null;
                if (httpResponseMessage.Content != null)
                {
                    str1 = await httpResponseMessage.Content.ReadAsStringAsync();
                }
                tResponse = (string.IsNullOrWhiteSpace(str1) ? default(TResponse) : JsonConvert.DeserializeObject<TResponse>(str1, FaceServiceClient.s_settings));
            }
            return tResponse;
        }

        public async Task TrainPersonGroupAsync(string personGroupId)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "train" };
            string str = string.Format("{0}/{1}/{2}/{3}", serviceHost);
            await this.SendRequestAsync<object, object>(HttpMethod.Post, str, null);
        }

        public async Task UpdateFaceListAsync(string faceListId, string name, string userData)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "facelists", faceListId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            await this.SendRequestAsync<object, object>(new HttpMethod("PATCH"), str, new { name = name, userData = userData });
        }

        public async Task UpdatePersonAsync(string personGroupId, Guid personId, string name, string userData = null)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}", serviceHost);
            await this.SendRequestAsync<object, object>(new HttpMethod("PATCH"), str, new { name = name, userData = userData });
        }

        public async Task UpdatePersonFaceAsync(string personGroupId, Guid personId, Guid persistedFaceId, string userData)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId, "persons", personId, "persistedfaces", persistedFaceId };
            string str = string.Format("{0}/{1}/{2}/{3}/{4}/{5}/{6}", serviceHost);
            await this.SendRequestAsync<object, object>(new HttpMethod("PATCH"), str, new { userData = userData });
        }

        public async Task UpdatePersonGroupAsync(string personGroupId, string name, string userData = null)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "persongroups", personGroupId };
            string str = string.Format("{0}/{1}/{2}", serviceHost);
            await this.SendRequestAsync<object, object>(new HttpMethod("PATCH"), str, new { name = name, userData = userData });
        }

        public async Task<VerifyResult> VerifyAsync(Guid faceId1, Guid faceId2)
        {
            object[] serviceHost = new object[] { this.ServiceHostCn, "verify" };
            string str = string.Format("{0}/{1}", serviceHost);
            VerifyResult verifyResult = await this.SendRequestAsync<object, VerifyResult>(HttpMethod.Post, str, new { faceId1 = faceId1, faceId2 = faceId2 });
            return verifyResult;
        }
    }
}