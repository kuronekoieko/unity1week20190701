using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using naichilab.Scripts.Internal;

public class TweetButton : MonoBehaviour
{
    public void OnClick()
    {
        string tweetText = "" + "\n\n#つながるﾈｺﾁｬﾝ\n#unity1week\n";
        naichilab.UnityRoomTweet.Tweet("tunagaru_nekochan", tweetText);

    }
}
