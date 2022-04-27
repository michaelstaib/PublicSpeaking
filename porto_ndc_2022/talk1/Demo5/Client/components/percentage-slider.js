import {Slider} from '@mui/material';
import {useEffect, useState} from 'react';

import {direction, formatPercent} from '@/utils';

const formatValue = (min, max) => (value) => {
  const suffix =
    value === min ? '(or less)' : value === max ? ' (or more)' : false;

  return (
    <>
      {formatPercent(value / 100, {
        minimumFractionDigits: 0,
        maximumFractionDigits: 1,
      })}
      {suffix && <br />}
      {suffix}
    </>
  );
};

export const PercentageSlider = (props) => {
  const [trend, setTrend] = useState();

  useEffect(() => {
    if (props.value !== undefined) {
      setTrend(direction(props.value));
    }
  }, [props.value]);

  const formatter = formatValue(props.min, props.max);

  return (
    <Slider
      color="secondary"
      aria-label="percentage"
      getAriaValueText={formatter}
      valueLabelFormat={formatter}
      valueLabelDisplay="on"
      marks
      track={false}
      {...props}
      onChange={(e, value) => {
        if (props.defaultValue !== undefined) {
          setTrend(direction(value));
        } else {
          props.onChange?.(e, value);
        }
      }}
      sx={[
        (theme) => ({
          '.MuiSlider-thumb': {color: theme.palette.trend[trend]},
          '.MuiSlider-valueLabel': {textAlign: 'center'},
        }),
        props.sx,
      ]}
    />
  );
};
