using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    private List<Story> stories = new List<Story>();
    private List<Story> stories2 = new List<Story>();
    private int currentStoryIndex = 0;
    private int currentStoryIndex2 = 0;



    // Story1
    public void AddStories(string rowStory)
    {
        string[] columns = rowStory.Split(',');
        Story newStory = new Story(columns[0].Trim('"'), columns[1].Trim('"'));
        stories.Add(newStory);
    }

    public List<Story> GetStories()
    {
        return stories;
    }

    public Story GetContent(int index){
        currentStoryIndex = index;
        return stories[index];
    }
    public Story NextContent(){
        if(currentStoryIndex < stories.Count - 1){
        currentStoryIndex+=1;
        return stories[currentStoryIndex];
        }
        Story nullStory = new Story("null", "0");
        return nullStory;
    }

    public void PrintStories()
    {
        foreach (var story in stories)
        {
            Debug.Log($"Content: {story.Content}, Character Number: {story.CharacterNumber}");
        }
    }

    //Story2
    public void AddStories2(string rowStory)
    {
        string[] columns = rowStory.Split(',');
        Story newStory = new Story(columns[0].Trim('"'), columns[1].Trim('"'));
        stories2.Add(newStory);
    }

    public List<Story> GetStories2()
    {
        return stories2;
    }

    public Story GetContent2(int index){
        currentStoryIndex = index;
        return stories2[index];
    }
    public Story NextContent2(){
        if(currentStoryIndex < stories2.Count - 1){
        currentStoryIndex+=1;
        return stories2[currentStoryIndex];
        }
        Story nullStory = new Story("null", "0");
        return nullStory;
    }

    public void PrintStories2()
    {
        foreach (var story in stories2)
        {
            Debug.Log($"Content: {story.Content}, Character Number: {story.CharacterNumber}");
        }
    }
}
