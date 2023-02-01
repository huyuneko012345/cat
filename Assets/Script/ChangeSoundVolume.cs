using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeSoundVolume : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider bgmSlider;
	public Slider seSlider;

	private void Start()
	{
		audioMixer.GetFloat("BGM_Volume", out float bgmVolume);
		bgmSlider.value = bgmVolume;
		audioMixer.GetFloat("SE_Volume", out float seVolume);
		seSlider.value = seVolume;

	}
	public void SetBGM(float volume)
	{
		audioMixer.SetFloat("BGM_Volume", volume);
	}
	public void SetSE(float volume)
	{
		audioMixer.SetFloat("SE_Volume", volume);
	}
}