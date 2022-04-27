import {css, keyframes} from '@emotion/css';
import {forwardRef} from 'react';

const rotate = keyframes`
  0% {
    transform: rotate(0deg);
  }
  50% {
    transform: rotate(180deg);
  }
  100% {
    transform: rotate(360deg);
  }
`;

export const Loader = forwardRef((props, ref) => (
  <div
    ref={ref}
    className={css`
      position: fixed;
      top: 0;
      right: 0;
      bottom: 0;
      left: 0;
      background-color: #202124;
      z-index: 1000;
    `}
    {...props}
  >
    <div
      className={css`
        position: absolute;
        left: 50%;
        top: 50%;
        margin-left: -75px;
        margin-top: -75px;
      `}
    >
      <div
        className={css`
          position: relative;
          width: 150px;
          height: 150px;
          padding: 8px;
          border-radius: 50%;
          border: 2px solid transparent;

          will-change: transform;
          animation: ${rotate} linear 3.5s infinite;
          border-top-color: #ff7e17;
          border-left-color: #666;
          border-right-color: #666;

          & * {
            height: 100%;
            padding: 8px;
            border-radius: 50%;
            border: 2px solid transparent;

            will-change: transform;
            animation: ${rotate} linear 3.5s infinite;
            border-top-color: #ff7e17;
            border-left-color: #666;
            border-right-color: #666;
          }
        `}
      >
        <div>
          <div>
            <div>
              <div>
                <div>
                  <div></div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
));
