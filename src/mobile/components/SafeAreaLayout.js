import React from 'react';
import { View, ViewProps } from 'react-native';
import { EdgeInsets, SafeAreaConsumer } from 'react-native-safe-area-context';
import { styled, StyledComponentProps } from '@ui-kitten/components';

const INSETS = {
  top: {
    toStyle: (insets, styles) => ({
      ...styles,
      paddingTop: insets.top,
    }),
  },
  bottom: {
    toStyle: (insets, styles) => ({
      ...styles,
      paddingBottom: insets.bottom,
    }),
  },
};

class SafeAreaLayoutComponent extends React.Component<SafeAreaLayoutProps> {

 styledComponentName = 'SafeAreaLayout';

  render() {
    return (
      <SafeAreaConsumer>
        {this.renderComponent}
      </SafeAreaConsumer>
    );
  }

  createInsets = (insets, safeAreaInsets, style) => {
    return React.Children.map(insets, inset => INSETS[inset].toStyle(safeAreaInsets, style));
  };

  renderComponent = (safeAreaInsets) => {
    const { style, insets, themedStyle, ...viewProps } = this.props;

    return (
      <View
        {...viewProps}
        style={[this.createInsets(insets, safeAreaInsets, themedStyle), style]}
      />
    );
  };
}

const SafeAreaLayout = styled(SafeAreaLayoutComponent);

export { SafeAreaLayoutComponent }