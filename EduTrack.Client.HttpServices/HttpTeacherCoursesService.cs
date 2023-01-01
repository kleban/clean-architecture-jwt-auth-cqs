﻿using EduTrack.WebUI.Shared.Common;
using EduTrack.WebUI.Shared.Courses;
using EduTrack.WebUI.Shared.Dtos.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.WebUI.Client.HttpServices
{
    public class HttpTeacherCoursesService : HttpBaseService
    {
        public HttpTeacherCoursesService(HttpClient httpClient) 
            : base(httpClient)  {}

        public async Task<IEnumerable<CourseReadDto>> GetListAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CourseReadDto>>(Shared.ApiHelpers.ApiUrl.Courses.Teacher.All);
        }

        public async Task<Guid> CreateCourseAsync(CourseCreateTypeEnum type)
        {
            var response = await _httpClient.PostAsJsonAsync<CourseCreateTypeEnum>(Shared.ApiHelpers.ApiUrl.Courses.Teacher.Create, type);
            var str = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }
    }
}
