using System;
using System.Collections.Generic;
using System.Linq;

public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }

    public int CompareTo(Team other)
    {
        int pointCompare = other.Points.CompareTo(Points); // Descending
        if (pointCompare != 0)
            return pointCompare;

        return Name.CompareTo(other.Name);
    }
}

public class Match
{
    public Team Team1 { get; }
    public Team Team2 { get; }

    public Match(Team t1, Team t2)
    {
        Team1 = t1;
        Team2 = t2;
    }

    public Match Clone()
    {
        return new Match(Team1, Team2);
    }
}

public class Tournament
{
    private List<Team> _teams = new();
    private LinkedList<Match> _schedule = new();
    private Stack<Match> _undoStack = new();

    public void AddTeam(Team team)
    {
        _teams.Add(team);
    }

    public void ScheduleMatch(Match match)
    {
        _schedule.AddLast(match);
    }

    public void RecordMatchResult(Match match, int score1, int score2)
    {
        _undoStack.Push(match.Clone());

        if (score1 > score2)
            match.Team1.Points += 3;
        else if (score2 > score1)
            match.Team2.Points += 3;
        else
        {
            match.Team1.Points += 1;
            match.Team2.Points += 1;
        }
    }

    public void UndoLastMatch()
    {
        if (_undoStack.Count == 0) return;

        var match = _undoStack.Pop();
        match.Team1.Points = 0;
        match.Team2.Points = 0;
    }

    public List<Team> GetRankings()
    {
        return _teams.OrderBy(t => t).ToList();
    }

    public int GetTeamRanking(Team team)
    {
        var rankings = GetRankings();
        return rankings.IndexOf(team) + 1;
    }
}
