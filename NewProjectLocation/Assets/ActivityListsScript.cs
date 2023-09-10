using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityListsScript : MonoBehaviour
{
    public List<List<string>> DailyActivity = new List<List<string>>();
    void Start()
    {
        createEmotionLists();
        createHygieneList();
        createBudgetList();
        createTimeList();
    }
    void createEmotionLists() 
    {
        List<string> emotionList = new List<string>
        {
            "Improved Mental Health",
            "Enhanced Emotional Support",
            "Stress Reduction",
            "Increased Confidence",
            "Building Relationships",
            "Intellectual Stimulation",
            "Physical Health Benefits",
            "Cultural Exchange",
            "Opportunities for Fun",
            "Increased Happiness",
            "Conflict and Disagreements",
            "Stress and Social Pressure",
            "Exposure to Negative Influences",
            "Time Consumption",
            "Energy Drain",
            "Risk of Gossip and Rumors",
            "Peer Pressure",
            "Emotional Vulnerability",
            "Rejection",
            "Overcommitment"
        };
        DailyActivity.Add(emotionList);
    }
    void createHygieneList()
    {
        List<string> hygieneList = new List<string>
        {
            "Regular Handwashing",
            "Dental Care",
            "Bathing/Showering",
            "Clean Clothes",
            "Nail Care",
            "Hair Care",
            "Fresh Breath",
            "Clean Living Environment",
            "Healthy Diet",
            "Sleep Hygiene",
            "Lack of Handwashing",
            "Poor Dental Hygiene",
            "Infrequent Bathing/Showering",
            "Wearing Dirty Clothes",
            "Neglecting Nail Care",
            "Hair Neglect",
            "Ignoring Bad Breath",
            "Neglecting Home Cleanliness",
            "Unhealthy Diet",
            "Disrupted Sleep Patterns"
        };
        DailyActivity.Add(hygieneList);
    }
    void createBudgetList()
    {
        List<string> budget = new List<string>
        {
            "Financial Security",
            "Debt Reduction",
            "Savings Growth",
            "Goal Achievement",
            "Reduced Stress",
            "Improved Credit Score",
            "Better Spending Habits",
            "Financial Awareness",
            "Wealth Building",
            "Financial Freedom",
            "Discipline Required",
            "Initial Setup",
            "Sacrifices",
            "Unexpected Expenses",
            "Lifestyle Changes",
            "Accountability",
            "Monitoring",
            "Limited Flexibility",
            "Frustration",
            "Frustration"
        };
        DailyActivity.Add(budget);
    }
    void createTimeList()
    {
        List<string> Time = new List<string>
        {
            "Productivity Boos",
            "Quality Family Time",
            "Hobbies and Interests",
            "Exercise and Fitness",
            "Learning Opportunities",
            "Rest and Relaxation",
            "Volunteer Work",
            "Personal Projects",
            "Travel and Exploration",
            "Mental Well-being",
            "Procrastination",
            "Boredom",
            "Unhealthy Habits",
            "Isolation",
            "Financial Implications",
            "Stress Overcommitment",
            "Missed Opportunities",
            "Lack of Routine",
            "Creativity Blocks",
            "Dependency"
        };
        DailyActivity.Add(Time);
    }
}
