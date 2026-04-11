const Breakpoint = {
  none: 0,
  xs: 1,
  sm: 2,
  md: 3,
  lg: 4,
  xl: 5,
};

function currentBreakpoint() {
  const w = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
  if (w < 576) return Breakpoint.xs;
  if (w < 768) return Breakpoint.sm;
  if (w < 992) return Breakpoint.md;
  if (w < 1200) return Breakpoint.lg;
  return Breakpoint.xl;
}

function notify(dotNetRef) {
  if (!dotNetRef) return;

  dotNetRef.invokeMethodAsync("UpdateBreakpoint", currentBreakpoint()).catch(() => {
    // Ignore JS interop failures during page teardown.
  });
}

export function StartBreakpointService(dotNetRef) {
  let active = true;
  let resizeObserver = null;

  const onResize = () => {
    if (active) notify(dotNetRef);
  };

  notify(dotNetRef);

  if (typeof ResizeObserver !== "undefined") {
    resizeObserver = new ResizeObserver(onResize);
    resizeObserver.observe(document.body);
  } else {
    window.addEventListener("resize", onResize);
  }

  return {
    dispose: () => {
      active = false;
      if (resizeObserver) {
        resizeObserver.disconnect();
      }
      window.removeEventListener("resize", onResize);
    },
  };
}
