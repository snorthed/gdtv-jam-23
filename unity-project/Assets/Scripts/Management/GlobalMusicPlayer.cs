using Helpers;
using UnityEngine;

namespace Management
{
    public class GlobalMusicPlayer : MonoBehaviour
    {
		public AudioSource mainAudioSource;
		public AudioSource interuptSource;

		public float defaultFadeSeconds = 5;

		[SerializeField]
        protected AudioClip currentClip;

        public AudioClip CurrentPlayingTrack
        {
            get => currentClip;
            protected set => currentClip = value;
        }

        protected AudioClip _nextClip;

		protected float _nextTrackFadeSeconds;
		protected float _trackVolume;

        public void Start()
        {
            _trackVolume = mainAudioSource.volume;
            mainAudioSource.volume = 0;
        }


        public void PlayNewAudio(AudioClip clip, bool fade = true, float fadeSeconds = 2f)
        {
            if (fade)
            {
                _nextClip = clip;
                _nextTrackFadeSeconds = fadeSeconds;
				_trackVolume = mainAudioSource.volume;

                StartCoroutine(FadingHelperFunction.StartFade(mainAudioSource, fadeSeconds, 0f, FadeoutFinishedEvent));
            }
            else
            {
                PlayNewTrackImmediate(clip);
            }
        }

        private void FadeoutFinishedEvent()
        {
            PlayNewTrackImmediate(_nextClip);
            StartCoroutine(FadingHelperFunction.StartFade(mainAudioSource, _nextTrackFadeSeconds, _trackVolume, null));
        }

        public void PlayNewTrackImmediate(AudioClip clip, bool resetVolume = false)
        {
            currentClip = clip;
            mainAudioSource.Stop();
            mainAudioSource.clip = clip;
            mainAudioSource.Play();

            if (resetVolume)
            {
                mainAudioSource.volume = _trackVolume;
            }
        }

		public void Pause() => Pause(mainAudioSource);
        public void Pause(AudioSource source) => source.Pause();

		public void Play() => Play(mainAudioSource);
        public void Play(AudioSource source)
        {
            if (source.time > 0f)
            {
				source.UnPause();
            }
            else
            {
				source.Play();
            }
        }

		public void ActivateAltTrack(AudioClip track)
		{
			Pause(mainAudioSource);
			Play(interuptSource);
		}

		public void DeactivateAltTrack(AudioClip track)
		{
			Pause(interuptSource);
			Play(mainAudioSource);
		}


		public void PlayOneShot(AudioClip clip) => mainAudioSource.PlayOneShot(clip);
	}
}
