import styled from '@emotion/styled';
import {useDropzone} from 'react-dropzone';

const Root = styled.div(
  ({theme}) => `
  margin: auto;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: ${theme.spacing(4)};
  border: 2px dashed ${theme.palette.primary.main};
  opacity: 75%;
  outline: none;
  cursor: copy;

  :hover,
  :focus {
    opacity: 1;
  }
`,
);

export const ImageDropzone = (props) => {
  const {getRootProps, getInputProps, isDragActive} = useDropzone({
    accept: 'image/gif, image/jpeg, image/png',
    ...props,
  });

  return (
    <Root {...getRootProps()}>
      <input {...getInputProps()} />
      <p>
        {isDragActive
          ? 'Drop the files here ...'
          : "Drag 'n' drop some files here, or click to select files"}
      </p>
    </Root>
  );
};
