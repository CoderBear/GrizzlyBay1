﻿using UnityEngine;

namespace PixelCrushers.LoveHate
{

    /// <summary>
    /// This optional component adds a more customizable emotion model based on PAD values than the
    /// PAD's built-in Temperament value.
    /// </summary>
    [AddComponentMenu("Love\u2215Hate/Emotional State")]
    [RequireComponent(typeof(FactionMember))]
    public class EmotionalState: MonoBehaviour, IModifyPadDeedEventHandler
    {

        /// <summary>
        /// The template to use when defining emotions.
        /// </summary>
        public EmotionModel emotionModelTemplate;

        /// <summary>
        /// The emotion definitions for this faction member.
        /// </summary>
        public EmotionDefinition[] emotionDefinitions = new EmotionDefinition[0];

        /// <summary>
        /// Index into emotionDefinitions of the current emotion based on the faction member's PAD values.
        /// </summary>
        public int currentEmotion = -1;

        /// <summary>
        /// The emotion name associated with the current emotion.
        /// </summary>
        public string currentEmotionName = string.Empty;

        private FactionMember m_member = null;

        public void Awake()
        {
            m_member = GetComponent<FactionMember>();
        }

        /// <summary>
        /// Updates the current emotion based on the faction member's PAD values.
        /// </summary>
        public void UpdateEmotionalState()
        {
            GetCurrentEmotionName();
        }

        /// <summary>
        /// Returns the name of the current emotion determined by the faction member's PAD values.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentEmotionName()
        {
            var currentEmotion = GetCurrentEmotion();
            currentEmotionName = (0 <= currentEmotion && currentEmotion < emotionDefinitions.Length)
                ? emotionDefinitions[currentEmotion].name : string.Empty;
            return currentEmotionName;
        }

        /// <summary>
        /// Returns the current emotion determined by the faction member's PAD values.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentEmotion()
        {
            for (int i = 0; i < emotionDefinitions.Length; i++)
            {
                if (IsWithinEmotionRange(emotionDefinitions[i]))
                {
                    currentEmotion = i;
                    return currentEmotion;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns `true` if the current PAD values fall within the ranges specified by
        /// an emotionDefinition.
        /// </summary>
        /// <param name="emotionDefinition">Emotion definition to check</param>
        /// <returns>True if within the range</returns>
        public bool IsWithinEmotionRange(EmotionDefinition emotionDefinition)
        {
            return (emotionDefinition.pleasureMin <= m_member.pad.pleasure && m_member.pad.pleasure <= emotionDefinition.pleasureMax) &&
                (emotionDefinition.arousalMin <= m_member.pad.arousal && m_member.pad.arousal <= emotionDefinition.arousalMax) &&
                (emotionDefinition.dominanceMin <= m_member.pad.dominance && m_member.pad.dominance <= emotionDefinition.dominanceMax);
        }

        /// <summary>
        /// Updates the current emotion whenever the faction member's PAD values change.
        /// </summary>
        public void OnModifyPad(float happinessChange, float pleasureChange, float arousalChange, float dominanceChange)
        {
            UpdateEmotionalState();
        }

    }

}