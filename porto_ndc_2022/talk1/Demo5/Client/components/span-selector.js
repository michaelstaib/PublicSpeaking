import styled from '@emotion/styled';
import {ToggleButton, ToggleButtonGroup} from '@mui/material';
import {memo, useEffect, useState} from 'react';

const $ToggleButtonGroup = styled(ToggleButtonGroup)(
  ({busy}) => `
  .MuiToggleButton-root {
    border: 0;
    border-radius: 0;
  }

  .MuiToggleButton-root.Mui-selected {
    background-color: unset;
    cursor: ${busy};
  }
`,
);

export const SpanSelector = memo(function SpanSelector({span, busy, onChange}) {
  const [activity, setActivity] = useState(undefined);

  useEffect(() => {
    if (busy) {
      const timeout = setTimeout(() => {
        setActivity('progress');
      }, 500);

      return () => {
        clearTimeout(timeout);
        setActivity(undefined);
      };
    }
  }, [busy]);

  return (
    <$ToggleButtonGroup
      color="primary"
      value={span}
      exclusive
      busy={activity}
      onChange={(e, value) => {
        if (value) {
          onChange(e, value);
        }
      }}
    >
      <ToggleButton value="HOUR" children="1H" />
      <ToggleButton value="DAY" children="1D" />
      <ToggleButton value="WEEK" children="1W" />
      <ToggleButton value="MONTH" children="1M" />
      <ToggleButton value="YEAR" children="1Y" />
      <ToggleButton value="ALL" children="ALL" />
    </$ToggleButtonGroup>
  );
});
