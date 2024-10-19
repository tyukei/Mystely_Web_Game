using System.Collections.Generic;
using UnityEngine;

public class StoryModel
{
    private List<Story> stories = new List<Story>();
    private int currentStoryIndex = 0;
    public void AddStories(string rowStory)
    {
        string[] columns = rowStory.Split(',');
        // delete ""
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
}
