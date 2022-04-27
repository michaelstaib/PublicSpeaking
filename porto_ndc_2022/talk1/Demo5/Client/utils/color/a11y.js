import {decomposeColor, getContrastRatio} from '@mui/material';

/**
 * Converts an RGB color value to HSL.
 *
 * Conversion formula adapted from http://en.wikipedia.org/wiki/HSL_color_space.
 * Assumes r, g, and b are contained in the set [0, 255] and returns h, s, and l in the set [0, 1].
 *
 * @param {number} r The red color value
 * @param {number} g The green color value
 * @param {number} b The blue color value
 * @returns {number[]} The HSL representation
 */
const rgbToHsl = (r, g, b) => {
  (r /= 255), (g /= 255), (b /= 255);

  const max = Math.max(r, g, b);
  const min = Math.min(r, g, b);
  let h;
  let s;
  const l = (max + min) / 2;

  if (max == min) {
    h = s = 0; // achromatic
  } else {
    const d = max - min;
    s = l > 0.5 ? d / (2 - max - min) : d / (max + min);

    switch (max) {
      case r:
        h = (g - b) / d + (g < b ? 6 : 0);
        break;
      case g:
        h = (b - r) / d + 2;
        break;
      case b:
        h = (r - g) / d + 4;
        break;
    }

    h /= 6;
  }

  return [h, s, l];
};

/**
 * Converts an HSL color value to RGB.
 *
 * Conversion formula adapted from http://en.wikipedia.org/wiki/HSL_color_space.
 * Assumes h, s, and l are contained in the set [0, 1] and returns r, g, and b in the set [0, 255].
 *
 * @param {number} h The hue value
 * @param {number} s The saturation value
 * @param {number} l The lightness value
 * @returns {number[]} The RGB representation
 */
const hslToRgb = (h, s, l) => {
  let r;
  let g;
  let b;

  if (s == 0) {
    r = g = b = l; // achromatic
  } else {
    function hue2rgb(p, q, t) {
      if (t < 0) t += 1;
      if (t > 1) t -= 1;
      if (t < 1 / 6) return p + (q - p) * 6 * t;
      if (t < 1 / 2) return q;
      if (t < 2 / 3) return p + (q - p) * (2 / 3 - t) * 6;
      return p;
    }

    const q = l < 0.5 ? l * (1 + s) : l + s - l * s;
    const p = 2 * l - q;

    r = hue2rgb(p, q, h + 1 / 3);
    g = hue2rgb(p, q, h);
    b = hue2rgb(p, q, h - 1 / 3);
  }

  return [Math.floor(r * 255), Math.floor(g * 255), Math.floor(b * 255)];
};

/**
 * Converts a CSS color value to HSL.
 *
 * @param {string} color The CSS color (i.e., #nnn, #nnnnnn, rgb(), rgba(), hsl(), hsla())
 * @returns {number[]} The HSL representation
 */
const strToHsl = (color) => {
  const {
    values: [r, g, b],
  } = decomposeColor(color);

  return rgbToHsl(r, g, b);
};

/**
 * Converts an RGB color value to HEX.
 *
 * Assumes r, g, and b are contained in the set [0, 255] and returns a RGB in hexadecimal notation.
 *
 * @param {number} r The red color value
 * @param {number} g The green color value
 * @param {number} b The blue color value
 * @returns {string} The HEX representation (i.e., #nnnnnn)
 */
const rgbToHex = (r, g, b) => {
  const intToHex = (int) => int.toString(16).padStart(2, '0');

  return `#${intToHex(r)}${intToHex(g)}${intToHex(b)}`;
};

/**
 * Converts an HSL color value to HEX.
 *
 * Assumes h, s, and l are contained in the set [0, 1] and returns a RGB in hexadecimal notation.
 *
 * @param {number} h The hue value
 * @param {number} s The saturation value
 * @param {number} l The lightness value
 * @returns {string} The HEX representation (i.e., #nnnnnn)
 */
const hslToHex = (h, s, l) => {
  const [r, g, b] = hslToRgb(h, s, l);

  return rgbToHex(r, g, b);
};

/**
 * Finds the closest accessible color for a given contrast ratio.
 *
 * @example
 * findClosestAccessibleColor('#f7931a', '#fff'); // → #dd7c07
 *
 * @param {string} foregroundColor The CSS color (i.e., #nnn, #nnnnnn, rgb(), rgba(), hsl(), hsla())
 * @param {string} backgroundColor The CSS color (i.e., #nnn, #nnnnnn, rgb(), rgba(), hsl(), hsla())
 * @param {number} minContrastRatio The desired minimum contrast ratio (e.g., 3, 4.5, 7)
 * @returns {string} The HEX representation (i.e., #nnnnnn)
 */
export const findClosestAccessibleColor = (
  foregroundColor,
  backgroundColor,
  minContrastRatio = 3,
) => {
  if (getContrastRatio(foregroundColor, backgroundColor) >= minContrastRatio) {
    return foregroundColor;
  }

  const [h, s, l] = strToHsl(foregroundColor);

  const isLightBackground =
    getContrastRatio('#000', backgroundColor) >= minContrastRatio;
  const isDarkBackground =
    getContrastRatio('#fff', backgroundColor) >= minContrastRatio;

  let minLightness = 0;
  let maxLightness = 1;
  let isDarkColor = false;

  if (isLightBackground && isDarkBackground) {
    if (l >= 0.5) {
      minLightness = l;
    } else {
      maxLightness = l;
      isDarkColor = true;
    }
  } else if (isLightBackground) {
    maxLightness = l;
    isDarkColor = true;
  } else {
    minLightness = l;
  }

  // 100% HSL = 1 / 255 colors
  const minHexDiff = 1 / 255;

  let foundColor;

  while (!foundColor) {
    const midLightness = (minLightness + maxLightness) / 2;
    const midA11y = hslToHex(h, s, midLightness);

    if (getContrastRatio(midA11y, backgroundColor) >= minContrastRatio) {
      if (maxLightness - minLightness <= minHexDiff) {
        foundColor = midA11y;
      } else if (isDarkColor) {
        minLightness = midLightness;
      } else {
        maxLightness = midLightness;
      }
    } else if (isDarkColor) {
      maxLightness = midLightness;
    } else {
      minLightness = midLightness;
    }
  }

  return foundColor;
};
