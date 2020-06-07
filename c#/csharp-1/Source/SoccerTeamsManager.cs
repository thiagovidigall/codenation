using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Codenation.Challenge.Exceptions;

namespace Codenation.Challenge
{
    public class SoccerTeamsManager : IManageSoccerTeams
    {

        private List<Team> _teams;
        private List<Player> _players;

        public SoccerTeamsManager()
        {
            _teams = new List<Team>();
            _players = new List<Player>();

        }

        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            try
            {
                Team objTeam = new Team(id, name, createDate, mainShirtColor, secondaryShirtColor);

                if (_teams.Contains(objTeam))
                    throw new UniqueIdentifierException();
                else
                    _teams.Add(objTeam);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            try
            {
                if (_teams.Count == 0 || !_teams.Exists(x => x.Id.Equals(teamId)))
                    throw new TeamNotFoundException();

                Player objPlayer = new Player(id, teamId, name, birthDate, skillLevel, salary);

                if (_players.Contains(objPlayer))
                    throw new UniqueIdentifierException();
                else
                    _players.Add(objPlayer);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void SetCaptain(long playerId)
        {
            Player newCaptain = _players.FirstOrDefault(x => x.Id.Equals(playerId));

            if (newCaptain == null)
                throw new PlayerNotFoundException();

            Player oldCaptain = _players.Find(x => x.TeamId.Equals(newCaptain.TeamId) && x.isCaptain);
            if (oldCaptain != null)
            {
                oldCaptain.isCaptain = false;
            }

            newCaptain.isCaptain = true;
        }

        public long GetTeamCaptain(long teamId)
        {
            if (_teams.Count == 0 || !_teams.Exists(x => x.Id.Equals(teamId)))
                throw new TeamNotFoundException();

            Player captain = _players.FirstOrDefault(x => x.TeamId.Equals(teamId) && x.isCaptain);

            if (captain == null)
                throw new CaptainNotFoundException();
            else
                return captain.Id;
        }

        public string GetPlayerName(long playerId)
        {
            Player objPlayer = _players.FirstOrDefault(x => x.Id.Equals(playerId));

            if (objPlayer == null)
                throw new PlayerNotFoundException();
            else
                return objPlayer.Name;
        }

        public string GetTeamName(long teamId)
        {
            Team objTeam = _teams.FirstOrDefault(x => x.Id.Equals(teamId));

            if (objTeam == null)
                throw new TeamNotFoundException();
            else
                return objTeam.Name;
        }

        public List<long> GetTeamPlayers(long teamId)
        {
            Team objTeam = _teams.FirstOrDefault(x => x.Id.Equals(teamId));

            if (objTeam == null)
                throw new TeamNotFoundException();
            else
                //return _players.Where(x => x.TeamId.Equals(objTeam.Id)).Select(x => x.Id).ToList();
                return (from pl in _players
                    where pl.TeamId.Equals(teamId)
                    orderby pl.Id ascending
                    select pl.Id).ToList();
        }

        public long GetBestTeamPlayer(long teamId)
        {
            Team objTeam = _teams.FirstOrDefault(x => x.Id.Equals(teamId));

            if (objTeam == null)
                throw new TeamNotFoundException();

            //jogador com maior skill e menor id se houver mais de um com o mesmo valor de skill
            return (from pl in _players
                    where pl.TeamId.Equals(objTeam.Id)
                    orderby pl.SkillLevel descending, pl.Id ascending
                    select pl.Id).First();
        }

        public long GetOlderTeamPlayer(long teamId)
        {
            Team objTeam = _teams.FirstOrDefault(x => x.Id.Equals(teamId));

            if (objTeam == null)
                throw new TeamNotFoundException();

            //jogador com maior idade e menor id se houver idades iguais
            return _players.Where(x => x.TeamId.Equals(objTeam.Id)).OrderBy(x => x.BirthDate).ThenBy(x => x.Id).First().Id;
        }

        public List<long> GetTeams()
        {
            if (_teams.Count > 0)
                return _teams.OrderBy(x => x.Id).Select(x => x.Id).ToList();

            return new List<long>();
        }

        public long GetHigherSalaryPlayer(long teamId)
        {
            Team objTeam = _teams.FirstOrDefault(x => x.Id.Equals(teamId));

            if (objTeam == null)
                throw new TeamNotFoundException();

            //jogador com maior salário e menor id se houver salário iguais
            return _players.Where(x => x.TeamId.Equals(objTeam.Id)).OrderByDescending(x => x.Salary).ThenBy(x => x.Id).First().Id;
        }

        public decimal GetPlayerSalary(long playerId)
        {
            Player objPlayer = _players.FirstOrDefault(x => x.Id.Equals(playerId));

            if (objPlayer == null)
                throw new PlayerNotFoundException();
            else
                return objPlayer.Salary;
        }

        public List<long> GetTopPlayers(int top)
        {
            if (_players.Count > 0)
                return _players.OrderByDescending(x => x.SkillLevel).ThenBy(x => x.Id).Select(x => x.Id).ToList().Take(top).ToList();

            return new List<long>();
        }

        public string GetVisitorShirtColor(long teamId, long visitorTeamId)
        {
            Team tCasa = _teams.FirstOrDefault(x => x.Id.Equals(teamId));
            Team tFora = _teams.FirstOrDefault(x => x.Id.Equals(visitorTeamId));

            if (tCasa == null || tFora == null)
                throw new TeamNotFoundException();

            if (tCasa.MainShirtColor.Equals(tFora.MainShirtColor))
                return tFora.SecondaryShirtColor;
            else
                return tFora.MainShirtColor;

        }

    }
}
