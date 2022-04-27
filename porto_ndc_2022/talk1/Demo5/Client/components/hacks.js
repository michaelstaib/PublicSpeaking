import Script from 'next/script';

export const Hacks = () =>
  process.env.NODE_ENV === 'development' && (
    <Script
      id="hacks"
      strategy="afterInteractive"
      // eslint-disable-next-line react/no-danger
      dangerouslySetInnerHTML={{
        __html: `
        {
          const style = document.createElement('style');
          style.innerHTML = '.nextjs-toast-errors-parent { display: none; }';
          let flag = false;

          const observer = new MutationObserver(function (mutations) {
            const host = document.querySelector('nextjs-portal');

            if (host) {
              if (!flag) {
                host.shadowRoot.appendChild(style);
                flag = true;
              }
            } else if (flag) {
              flag = false;
            }
          });

          observer.observe(document.body, {childList: true});
        }
       `,
      }}
    />
  );
