using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public List<AudioClip> songs;
    private int songIndex = 0;

    private string absolutePath = "./music";
    
    // Start is called before the first frame update
    void Start()
    {
        GetSongsFromFolder();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            musicSource.Stop();
            musicSource.clip = songs[songIndex];
            songIndex++;
            if(songIndex >= songs.Count)
            {
                songIndex = 0;
            }
            musicSource.Play();
        }
        
    }

    private void GetSongsFromFolder()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
        FileInfo[] songFiles = directoryInfo.GetFiles("*.*");

        foreach (FileInfo songFile in songFiles)
        {
            StartCoroutine(ConvertFilesToAudioClip(songFile));
            //return; //remove this when doing multiple songs
        }

    }

    private IEnumerator ConvertFilesToAudioClip(FileInfo songFile)
    {
        if (songFile.Name.Contains("meta"))
            yield break;
        else
        {
            string songName = songFile.FullName.ToString();
            string url = string.Format("file://{0}", songName);
            UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
            yield return www.SendWebRequest();
            var clip = DownloadHandlerAudioClip.GetContent(www);
            if (clip != null)
            {
                songs.Add(clip);
            }
        }
    }
}
