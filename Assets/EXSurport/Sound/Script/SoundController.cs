using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

namespace SupSystem
{
    public class SoundController : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<AudioClip> BGM;
        public List<AudioClip> SE;
        public List<AudioClip> Sound;
        public List<AudioClip> Special;
        public bool WipSence;
        public List<AudioSource> playingAudio;
        [SerializeField] GameObject AudioSource;
        [SerializeField] AudioMixer Mixer;
        void Start()
        {

            
            
            if (FindObjectsByType<SoundController>(0).Length > 1)
            {
                Destroy(gameObject);
            }
            if (WipSence)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        
        // Update is called once per frame
        public void PlayAudio(AudioClip sound, AudioType audioType, bool isLoop = false)
        {
            GameObject audio = Instantiate(AudioSource,transform);
            AudioSource source = audio.GetComponent<AudioSource>();
            source.outputAudioMixerGroup = Mixer.FindMatchingGroups(Enum.GetName(typeof(AudioType), audioType))[0];
            source.loop = isLoop;
            source.clip = sound;
            playingAudio.Add(source);
            source.Play();
            if (!isLoop) StartCoroutine(RemoveSound(source, source.clip.length + 0.1f));
        }
        public void PlayAudio(string sound, AudioType audioType, bool isLoop = false)
        {
            GameObject audio = Instantiate(AudioSource, transform);
            AudioSource source = audio.GetComponent<AudioSource>();
            source.outputAudioMixerGroup = Mixer.FindMatchingGroups(Enum.GetName(typeof(AudioType), audioType))[0];
            source.loop = isLoop;
            List<AudioClip> TargetList=null;
            switch (audioType)
            {
                
                case AudioType.BGM:
                    TargetList = BGM;
                    break;
                case AudioType.SE:
                    TargetList = SE;

                    break;
                case AudioType.Sound:

                    TargetList = Sound;
                    break;
                case AudioType.Special:
                    TargetList = Special;
                    break;
                default:
                    Debug.LogError("Don't input other type without List.");
                    break;
            }
            source.clip=TargetList.Find(e=>e.name== sound);
            playingAudio.Add(source);
            if (source.clip == null)
            {
                Debug.LogWarning("Can't find the music in this list.");
            }
            source.Play();
            if (!isLoop) StartCoroutine(RemoveSound(source, source.clip.length + 0.1f));
        }
        public void StopPlay(string name)
        {
            AudioSource source=playingAudio.Find(e=>e.clip.name== name);
            source.Pause(); StartCoroutine(RemoveSound(source, source.clip.length + 0.1f));
        }
        public void ControllMixerVolume(AudioType audioType, float vol)
        {
            Mixer.SetFloat(Enum.GetName(typeof(AudioType), audioType) + "Vol", vol);
        }
        IEnumerator RemoveSound(AudioSource sound,float time)
        {
            yield return new WaitForSeconds(time);
            playingAudio.Remove(sound);
            Destroy(sound.gameObject, 0);

        }
        public enum AudioType
        {
            Master,
            BGM,
            SE,
            Sound,
            Special
        }
    }
}