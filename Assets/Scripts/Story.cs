public struct Story
{
    public string Content { get; private set; }
    public string CharacterNumber { get; private set; }

    public Story(string content, string characterNumber)
    {
        Content = content;
        CharacterNumber = characterNumber;
    }
}
