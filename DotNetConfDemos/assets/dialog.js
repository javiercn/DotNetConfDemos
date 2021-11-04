import { fluentDialog } from '@fluentui/web-components/dist/esm/dialog/index';
import { provideFluentDesignSystem } from '@fluentui/web-components/dist/esm/fluent-design-system';

const allComponents = {
    fluentDialog,
    register(container, ...rest) {
        if (!container) {
            // preserve backward compatibility with code that loops through
            // the values of this object and calls them as funcs with no args
            return;
        }
        for (const key in this) {
            if (key === 'register') {
                continue;
            }
            this[key]().register(container, ...rest);
        }
    },
};

export const FluentDesignSystem = provideFluentDesignSystem().register(allComponents);

