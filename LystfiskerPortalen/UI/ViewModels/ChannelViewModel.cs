namespace LystfiskerPortalen.UI.ViewModels
{
    public class ChannelViewModel
    {
        public string ChannelId { get; set; }
        public string Name { get; set; }
        public IEnumerable<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    }
}
