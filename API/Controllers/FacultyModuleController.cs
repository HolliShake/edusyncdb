﻿using APPLICATION.IService;
using APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class FacultyModuleController:ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly IScheduleTeacherService _scheduleTeacher;
    private readonly IEnrollmentService _enrollment;
    private readonly IUserCampusDetailsService _userCampus;
    public FacultyModuleController(
        IJwtAuthManager jwtAuthManager,
        IScheduleTeacherService scheduleTeacher,
        IEnrollmentService enrollment,
        IUserCampusDetailsService userCampus
    )
    {
        _jwtAuthManager = jwtAuthManager;
        _scheduleTeacher = scheduleTeacher;
        _enrollment = enrollment;
        _userCampus = userCampus;
    }

    /****************** ACTION ROUTES ******************/
    /// <summary>
    /// Get current loggedin faculty schedules.
    /// </summary>
    /// <returns>Array[ScheduleTeacher]</returns>
    [HttpGet("Schedules/My")]
    public async Task<ActionResult> GetCurrentFacultySchedules()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        return Ok(await _scheduleTeacher.GetScheduleTeacherByUserId(userId));
    }

    /// <summary>
    /// Get currents user enrolled student by schedule id (pass id from "Schedules/My").
    /// </summary>
    /// <param name="scheduleId"></param>
    /// <returns>Array[Enrollment]</returns>
    [HttpGet("Students/My/{scheduleId:int}")]
    public async Task<ActionResult> GetEnrolledStudentByScheduleId(int scheduleId)
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        if (!(await _scheduleTeacher.HasShedule(userId, scheduleId)))
        {
            return NotFound("Schedule not found for user!");
        }
        return Ok(await _enrollment.GetEnrollmentsByScheduleId(scheduleId));
    }

    /// <summary>
    /// Get all campus that I have access.
    /// </summary>
    /// <returns>Array[UserCampus]</returns>
    [HttpGet("CampusAccess/My")]
    public async Task<ActionResult> GetFacultyCampusAccess()
    {
        var accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace($"{JwtBearerDefaults.AuthenticationScheme} ", String.Empty);
        var principal = _jwtAuthManager.DecodeJwtToken(accessToken);
        var userId = principal.Item1.FindFirst(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? "0";
        return Ok(await _userCampus.GetAllCampusByUserId(userId));
    }
}