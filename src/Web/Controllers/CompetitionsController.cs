﻿using CotdQualifierRank.Domain.DomainPrimitives;
using CotdQualifierRank.Web.DTOs;
using CotdQualifierRank.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CotdQualifierRank.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompetitionsController(CompetitionService competitionService) : ControllerBase
{
    [HttpGet("{mapUid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompetitionDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCompetitionByMap(string mapUid)
    {
        if (!MapUid.IsValid(mapUid))
            return BadRequest("Requested mapUid is not valid");
                
        var competitionDTO = competitionService.GetCompetitionDTOByMapUid(new MapUid(mapUid), false);

        if (competitionDTO is null)
            return NotFound();

        return Ok(competitionDTO);
    }

    [HttpGet("{competitionId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompetitionDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCompetitionByCompetitionId(int competitionId)
    {
        var competition = competitionService.GetCompetitionDTOByCompetitionId(competitionId, false);

        if (competition is null)
            return NotFound();

        return Ok(competition);
    }

    [HttpGet("{mapUid}/leaderboard")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<int>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCompetitionLeaderboardByMapUid(string mapUid)
    {
        if (!MapUid.IsValid(mapUid))
            return BadRequest("Requested mapUid is not valid");
                
        return Ok(competitionService.GetLeaderboardByMapUid(new MapUid(mapUid)));
    }

    [HttpGet("{competitionId:int}/leaderboard")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<int>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetCompetitionLeaderboardByChallengeId(int competitionId)
    {
        return Ok(competitionService.GetLeaderboardByCompetitionId(competitionId));
    }
}