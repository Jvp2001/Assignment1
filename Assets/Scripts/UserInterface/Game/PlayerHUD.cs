// © 2020 Joshua Petersen. All rights reserved.
/// <file>
/// <copyright> © 2020 Joshua Petersen. All rights reserved. </copyright>
/// </file>

using Assignment1;
using Assignment1.Gameplay;
using Unity.UIElements.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

namespace UserInterface.Game
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// I violated the naming convention due to HUD being an acronym.
    /// </remarks>
    [RequireComponent(typeof(PanelRenderer))]
    public class PlayerHUD : Singleton<PlayerHUD>
    {
    
        private PanelRenderer panelRenderer;

        private Label amountCollected;

        private Label timerLabel;

        // Start is called before the first frame update
        void Start()
        {
            
            panelRenderer = GetComponent<PanelRenderer>();
            amountCollected = panelRenderer.visualTree.Query<Label>(name: "AmountCollected");
            timerLabel = panelRenderer.visualTree.Query<Label>(name: "Timer");
        }

        // Update is called once per frame
        void Update()
        {
            panelRenderer.visualTree.MarkDirtyRepaint();
        
            timerLabel.text = GameplayManager.Instance.Timer.ToString();

        }
    }
}