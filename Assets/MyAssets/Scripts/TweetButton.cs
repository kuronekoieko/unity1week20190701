using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using naichilab.Scripts.Internal;

public class TweetButton : MonoBehaviour
{
    public void OnClick()
    {
        string tweetText = "ハート数：" + Variables.getHeartNum + " ランク：" + Variables.rank + "\n\n#あつめるﾈｺﾁｬﾝ\n#unity1week\n";
        naichilab.UnityRoomTweet.Tweet("atumeru_nekochan", tweetText);
        AudioManager.i.PlayOneShot(0);
    }
}
