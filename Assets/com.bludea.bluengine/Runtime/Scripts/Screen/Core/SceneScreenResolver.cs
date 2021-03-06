using System.Collections;
using System.Collections.Generic;
using Bludk;

namespace BluEngine
{
    public class SceneScreenResolver : IScreenResolver
    {
        private readonly ScreenSceneRoot _screenSceneRoot;

        public SceneScreenResolver(ScreenSceneRoot screenSceneRoot)
        {
            _screenSceneRoot = screenSceneRoot;
        }

        public IEnumerator<TUI> Load<TUI>() where TUI : ScreenUI
        {
            TUI ui = _screenSceneRoot.transform.GetComponentInChildren<TUI>(true);
            return ui.Yield();
        }

        public IEnumerator Unload<TUI>(TUI ui) where TUI : ScreenUI
        {
            ui.gameObject.SetActive(false);
            return TxongaHelper.Empty();
        }
    }
}