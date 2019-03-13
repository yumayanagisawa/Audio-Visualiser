using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Audio;


public class TimelineManager : MonoBehaviour
{
    public AudioManager audioManager;

    public PlayableGraph playableGraph; //you could make this a list to be able to save multiple tracks

    //public PlayableDirector playableDirector;
   // public TimelineAsset timelineAsset;

    public List<GameObject> trackList = new List<GameObject>();

    private AudioTrack audiTrack;



    private void Start()
    {
        //playableDirector = this.GetComponent<PlayableDirector>();
        //playableDirector.playableAsset = timelineAsset;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            PlayGraph();
        }
    }
    private void PlayGraph()
    {
        playableGraph = PlayableGraph.Create();
        playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);

        AudioPlayableOutput audioOutput = AudioPlayableOutput.Create(playableGraph, "AudioOut", audioManager.musicSource);

        AudioClipPlayable clipPlayable = AudioClipPlayable.Create(playableGraph, audioManager.songs[audioManager.selectedSongIndex], false);

        audioOutput.SetSourcePlayable(clipPlayable);

        AudioMixerPlayable mixer = AudioMixerPlayable.Create(playableGraph);


        //playableDirector.SetGenericBinding();

        

        //audiTrack = playableGraph.Co
        //audiTrack.CreateClip(audioManager.songs[audioManager.selectedSongIndex]);
        //audiTrack.CreatePlayable(playableGraph, this.gameObject);
        playableGraph.Play();
       // BindTimelineTracks();
        //playableDirector.Play();
    }

    //public void BindTimelineTracks()
    //{
    //    Debug.Log("Binding Timeline Tracks!");
    //    timelineAsset = (TimelineAsset)playableDirector.playableAsset;
    //    // iterate through tracks and map the objects appropriately
    //    for (var i = 0; i < trackList.Count; i++)
    //    {
    //        if (trackList[i] != null)
    //        {
    //            var track = timelineAsset.outputs
    //            playableDirector.SetGenericBinding(track, trackList[i]);
    //        }
    //    }
    //}

    private void OnDestroy()
    {
        playableGraph.Destroy();
    }
}
