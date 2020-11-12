using System;
using Cybermage.Events;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Cybermage.Common
{
    public class WorldUI : MonoBehaviour
    {
        private void Awake()
        {
            SetDetails();
            SetFeatures();
            SetSkills(GlobalsConfig.Information.skills[0], 7.5f);
            SetSkills(GlobalsConfig.Information.skills[1], 0);
            SetSkills(GlobalsConfig.Information.skills[2], -7.5f);
            SetFolio(GlobalsConfig.Information.folio[0], 22);
            SetFolio(GlobalsConfig.Information.folio[1], 0);
            SetFolio(GlobalsConfig.Information.folio[2], -22);
        }

        private void SetSkills(Skills informationSkill, float d)
        {
            Transform skillTransform = Instantiate(CM_Resources.prefabs.ui.skillsContainer.Load(), transform).transform;
            skillTransform.position = new Vector3(skillTransform.position.x, skillTransform.position.y, d);
            TextMeshProUGUI title = Utilities.FindDeepChild<TextMeshProUGUI>(skillTransform, "title");
            title.text = informationSkill.header;
            TextMeshProUGUI content = Utilities.FindDeepChild<TextMeshProUGUI>(skillTransform, "text");
            content.text = informationSkill.content;
        }

        private void SetFolio(Folio informationFeature, float p1)
        {
            Transform folioTransform = Instantiate(CM_Resources.prefabs.ui.folioContainer.Load(), transform).transform;
            folioTransform.position = new Vector3(folioTransform.position.x, folioTransform.position.y, p1);
            TextMeshProUGUI title = Utilities.FindDeepChild<TextMeshProUGUI>(folioTransform, "title");
            title.text = informationFeature.header;
            Transform tagTransform = Utilities.FindDeepChild(folioTransform, "tagsContainer");
            
            foreach (string tag in informationFeature.tags)
            {
                TextMeshProUGUI text = Instantiate(CM_Resources.prefabs.ui.worldSpaceSubHeader.Load(), tagTransform).GetComponent<TextMeshProUGUI>();
                text.text = tag;
            }
            
            TextMeshProUGUI content = Utilities.FindDeepChild<TextMeshProUGUI>(folioTransform, "text");
            content.text = informationFeature.content;
        }

        private void SetFeatures()
        {
            Transform featureTransform = Utilities.FindDeepChild(this.transform, "featureContainer");
            Transform featureContentTransform = Utilities.FindDeepChild(featureTransform, "Content");

            foreach (string feature in GlobalsConfig.Information.features)
            {
                GameObject go = Instantiate(CM_Resources.prefabs.ui.worldSpaceSubHeader.Load(),
                    featureContentTransform);
                TextMeshProUGUI text = go.GetComponent<TextMeshProUGUI>();
                text.text = feature;
                text.alignment = TextAlignmentOptions.Right;
                text.color = CM_Theme.H3;
            }
        }
        
        private void SetDetails()
        {
            Biography bio = GlobalsConfig.Information.biography;
            Transform detailsTransform = Utilities.FindDeepChild(this.transform, "detailsContainer");
            Transform detailsContentTransform = Utilities.FindDeepChild(detailsTransform, "Content");

            TextMeshProUGUI headerText = Instantiate(
                CM_Resources.prefabs.ui.worldSpaceHeader.Load(), 
                detailsContentTransform)
                .GetComponent<TextMeshProUGUI>();
            headerText.text = bio.name;
            headerText.alignment = TextAlignmentOptions.Left;
            headerText.color = CM_Theme.H1;

            TextMeshProUGUI bodyText = Instantiate(
                CM_Resources.prefabs.ui.worldSpaceText.Load(), 
                detailsContentTransform)
                .GetComponent<TextMeshProUGUI>();
            bodyText.text = bio.content;
            bodyText.alignment = TextAlignmentOptions.Left;
            bodyText.color = CM_Theme.Text;
            
            TextMeshProUGUI linkText_1 = Instantiate(
                CM_Resources.prefabs.ui.worldSpaceLink.Load(), 
                detailsContentTransform)
                .GetComponent<TextMeshProUGUI>();
            linkText_1.text = bio.email;
            linkText_1.alignment = TextAlignmentOptions.Left;
            linkText_1.gameObject.AddComponent<WebLink>().SetURL(bio.email, linkText_1);
            linkText_1.color = CM_Theme.Link;

            TextMeshProUGUI linkText_2 = Instantiate(
                CM_Resources.prefabs.ui.worldSpaceLink.Load(), 
                detailsContentTransform)
                .GetComponent<TextMeshProUGUI>();
            linkText_2.text = bio.linkedin;
            linkText_2.alignment = TextAlignmentOptions.Left;
            linkText_2.gameObject.AddComponent<WebLink>().SetURL(bio.linkedin, linkText_2);
            linkText_2.color = CM_Theme.Link;

            TextMeshProUGUI linkText_3 = Instantiate(
                CM_Resources.prefabs.ui.worldSpaceLink.Load(), 
                detailsContentTransform)
                .GetComponent<TextMeshProUGUI>();
            linkText_3.text = bio.imdb;
            linkText_3.alignment = TextAlignmentOptions.Left;
            linkText_3.gameObject.AddComponent<WebLink>().SetURL(bio.imdb, linkText_3);
            linkText_3.color = CM_Theme.Link;

            //Set UI for rebuilding.
            UpdateUI(detailsContentTransform.GetComponent<VerticalLayoutGroup>());
        }

        //work around for content size fitter components
        private async UniTaskVoid UpdateUI<T>(T t) where T : MonoBehaviour
        {
            t.enabled = false;
            await UniTask.Delay(1);
            t.enabled = true;
            LayoutRebuilder.ForceRebuildLayoutImmediate(t.transform as RectTransform);
        }
    }
    
    class WebLink : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private string _webLink;
        private Button _button;
        private TextMeshProUGUI _textComponent;
        
        public void SetURL(string link, TextMeshProUGUI textComponent)
        {
            _webLink = link;
            _textComponent = textComponent;
            _button = gameObject.AddComponent<Button>();
            _button.onClick.AddListener(() =>
            {
                if (!string.IsNullOrEmpty(_webLink))
                {
                    Application.OpenURL(_webLink);
                }
            });

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _textComponent.color = CM_Theme.Link;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _textComponent.color = CM_Theme.LinkVisited;
        }
    }
}
