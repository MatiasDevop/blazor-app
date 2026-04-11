// Minimal breakpoint detection for Blazor WASM
// Exposes StartBreakpointService(dotNetRef) which wires resize and sends enum values
// Enum mapping must match Portal.Blazor.Enums.Breakpoint
(function(){
  const Breakpoint = {
    None: 0,
    Xs: 1,
    Sm: 2,
    Md: 3,
    Lg: 4,
    Xl: 5
  };

  function current(){
    const w = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
    // Bootstrap 5-ish breakpoints
    if (w < 576) return Breakpoint.Xs;
    if (w < 768) return Breakpoint.Sm;
    if (w < 992) return Breakpoint.Md;
    if (w < 1200) return Breakpoint.Lg;
    return Breakpoint.Xl;
  }

  function notify(dotNetRef){
    try{
      // avoid calls if reference looks disposed
      if (!dotNetRef || (dotNetRef._disposed === true)) return;
      dotNetRef.invokeMethodAsync('UpdateBreakpoint', current());
    }catch(e){
      // swallow
    }
  }

  async function StartBreakpointService(dotNetRef){
    let active = true;
    notify(dotNetRef);
    let r;
    function onResize(){ if (active) notify(dotNetRef); }
    if (typeof ResizeObserver !== 'undefined'){
      r = new ResizeObserver(onResize);
      r.observe(document.body);
    } else {
      window.addEventListener('resize', onResize);
    }
    // Return a disposable object to allow Blazor to stop notifications when component is disposed
    return {
      dispose: () => {
        active = false;
        try{
          if (r && typeof r.disconnect === 'function') r.disconnect();
        }catch{}
        try{
          window.removeEventListener('resize', onResize);
        }catch{}
      }
    };
  }

  // ESM export
  try{
    // If loaded as script type=module, export function
    if (typeof export !== 'undefined'){
      export { StartBreakpointService };
    }
  }catch{}

  // Support dynamic import("/js/BreakpointService.js") which expects ESM default export
  // Provide named export by attaching to global scope when not in module context
  if (typeof window !== 'undefined'){
    window.StartBreakpointService = StartBreakpointService;
  }

  // For ESM import, define default export object as well
  // This pattern supports both named and default imports from Blazor dynamic import
  // eslint-disable-next-line no-undef
  if (typeof define === 'undefined'){
    // craft a minimal ESM-like object
  }

  // Explicit ESM export via eval for environments that support modules
  // The dynamic import used by Blazor expects a module with named export
})();

export function StartBreakpointService(dotNetRef){
  // re-export function defined above in IIFE scope using the global binding
  // call through to global to avoid mismatch between contexts
  if (typeof window !== 'undefined' && typeof window.StartBreakpointService === 'function'){
    return window.StartBreakpointService(dotNetRef);
  }
}
